# **HTTPS for `lvh.me` in local development**

## **Overview**

`lvh.me` is a development domain that resolves to `127.0.0.1`, which makes it useful for testing local applications with hostnames and subdomains such as:

- `lvh.me`
- `app.lvh.me`
- `api.lvh.me`

To use HTTPS locally with `lvh.me`, create a certificate that includes:

- `lvh.me`
- `*.lvh.me`

There are two common approaches:

1. **mkcert** — recommended for day-to-day development
2. **OpenSSL self-signed certificate** — manual approach

---

## **Recommended approach: `mkcert`**

### **Why use it**

`mkcert` creates certificates signed by a local development CA that is trusted by your machine after setup. This avoids browser certificate warnings in normal local development.

### **Install `mkcert`**

#### **macOS**

brew install mkcert  
brew install nss

#### **Ubuntu/Debian**

sudo apt update  
sudo apt install mkcert

#### **Windows**

choco install mkcert

### **Install the local CA**

Run once per machine:

mkcert \-install

This adds the local development certificate authority to the system trust store.

### **Generate a certificate for `lvh.me`**

mkcert lvh.me "\*.lvh.me"

Typical output files:

- `lvh.me+1.pem`
- `lvh.me+1-key.pem`

These files can then be configured in your local web server, reverse proxy, or application server.

### **What this certificate covers**

The generated certificate is valid for:

- `https://lvh.me`
- `https://app.lvh.me`
- `https://anything.lvh.me`

### **Example usage**

#### **Nginx**

server {  
 listen 443 ssl;  
 server_name lvh.me \*.lvh.me;

ssl_certificate /path/to/lvh.me+1.pem;  
 ssl_certificate_key /path/to/lvh.me+1-key.pem;

location / {  
 proxy_pass http://127.0.0.1:3000;  
 }  
}

#### **Node.js HTTPS server**

const https \= require("https");  
const fs \= require("fs");  
const app \= require("./app");

https.createServer(  
 {  
 key: fs.readFileSync("./lvh.me+1-key.pem"),  
 cert: fs.readFileSync("./lvh.me+1.pem"),  
 },  
 app  
).listen(3000);

### **Notes**

- Best option for local development
- Browser trust works after `mkcert -install`
- Certificates are intended for local/dev use only
- Other machines will not trust your local CA unless it is installed there too

---

## **Manual approach: OpenSSL self-signed certificate**

### **Why use it**

Use this method when:

- `mkcert` is not available
- you want a simple self-signed certificate
- you are testing tooling that specifically expects a raw self-signed cert

### **Limitation**

Browsers and clients will usually show warnings unless the certificate or its issuing CA is manually trusted.

### **Generate certificate directly with SANs**

Run:

openssl req \-x509 \-nodes \-days 365 \\  
 \-newkey rsa:2048 \\  
 \-keyout lvh.me-key.pem \\  
 \-out lvh.me-cert.pem \\  
 \-subj "/CN=lvh.me" \\  
 \-addext "subjectAltName=DNS:lvh.me,DNS:\*.lvh.me"

This creates:

- `lvh.me-key.pem`
- `lvh.me-cert.pem`

### **What this certificate covers**

The certificate is valid for:

- `lvh.me`
- any one-level subdomain under `lvh.me`, such as `app.lvh.me`

### **Example usage**

#### **Nginx**

server {  
 listen 443 ssl;  
 server_name lvh.me \*.lvh.me;

ssl_certificate /path/to/lvh.me-cert.pem;  
 ssl_certificate_key /path/to/lvh.me-key.pem;

location / {  
 proxy_pass http://127.0.0.1:3000;  
 }  
}

#### **Node.js HTTPS server**

const https \= require("https");  
const fs \= require("fs");  
const app \= require("./app");

https.createServer(  
 {  
 key: fs.readFileSync("./lvh.me-key.pem"),  
 cert: fs.readFileSync("./lvh.me-cert.pem"),  
 },  
 app  
).listen(3000);

---

## **Alternative manual approach: OpenSSL config file**

Some environments do not support `-addext`. In that case, create a config file.

### **Example config file: `lvh.me.cnf`**

\[req\]  
default_bits \= 2048  
prompt \= no  
default_md \= sha256  
x509_extensions \= v3_req  
distinguished_name \= dn

\[dn\]  
CN \= lvh.me

\[v3_req\]  
subjectAltName \= @alt_names

\[alt_names\]  
DNS.1 \= lvh.me  
DNS.2 \= \*.lvh.me

### **Generate the certificate**

openssl req \-x509 \-nodes \-days 365 \\  
 \-newkey rsa:2048 \\  
 \-keyout lvh.me-key.pem \\  
 \-out lvh.me-cert.pem \\  
 \-config lvh.me.cnf

---

## **Trusting the manual self-signed certificate**

If you use raw OpenSSL self-signed certs, browsers usually warn because the certificate is not trusted by default.

Possible options:

- import the cert into your OS trust store
- import it into browser trust settings
- use a local CA instead of a leaf self-signed cert

In practice, if you need trusted local HTTPS, `mkcert` is usually the better solution.

---

## **Important constraints**

- `lvh.me` is not your domain, so this is for local development only
- You cannot generally issue a public CA certificate for arbitrary local use of `lvh.me`
- A self-signed or locally trusted certificate only works without warnings on machines that trust it
- Wildcard coverage for `*.lvh.me` does not usually cover deeper nested names like `a.b.lvh.me`

---

## **Recommendation**

For most developer workflows:

- use **`mkcert`** if you want local HTTPS without browser warnings
- use **OpenSSL** only when you need a manual self-signed certificate or want to test untrusted-cert behavior

---

## **Quick start summary**

### **Trusted local HTTPS**

mkcert \-install  
mkcert lvh.me "\*.lvh.me"

### **Plain self-signed certificate**

openssl req \-x509 \-nodes \-days 365 \\  
 \-newkey rsa:2048 \\  
 \-keyout lvh.me-key.pem \\  
 \-out lvh.me-cert.pem \\  
 \-subj "/CN=lvh.me" \\  
 \-addext "subjectAltName=DNS:lvh.me,DNS:\*.lvh.me"

---
