# aichat + Ollama Local Knowledge base

w

This document explains how to set up a **local terminal knowledge assistant** using:

- **aichat** (terminal chat interface)
- **Ollama** (local LLM runtime)
- **RAG over `~/.kb`**
- **embedding model `nomic-embed-text`**

The system allows asking questions about local configuration files and documentation such as:

```
what is my tmux prefix key
explain the editor fish function
how does my opencode config work
```

Everything runs **locally**.

---

# Architecture

```
tmux
  ↓
aichat
  ↓
RAG index
  ↓
~/.kb
  ↓
Ollama
  ├─ qwen2.5-coder:14b (LLM)
  └─ nomic-embed-text (embeddings)
```

---

# 1 Install prerequisites

## Install Ollama

```
brew install ollama
```

Start the server:

```
OLLAMA_CONTEXT_LENGTH=64000 ollama serve
```

**Notice:** You can make it permanent

```
nano ~/.zshrc

# in the file add this line

# Ollama configuration
export OLLAMA_CONTEXT_LENGTH=64000

```

Verify:

```
ollama list
```

---

## Install models

LLM model:

```
ollama pull qwen2.5-coder:14b
```

Embedding model:

```
ollama pull nomic-embed-text
```

---

## Install aichat

```
brew install aichat
```

Verify:

```
aichat --version
```

---

# 2 Configure aichat

First run:

```
aichat
```

During setup choose:

```
provider: openai-compatible
```

Set API base:

```
http://localhost:11434/v1
```

Set API key (anything works):

```
ollama
```

Default model:

```
qwen2.5-coder:14b
```

---

# Config file location

```
~/Library/Application Support/aichat/config.yaml
```

Example minimal configuration:

```yaml
# see https://github.com/sigoden/aichat/blob/main/config.example.yaml

model: ollama:qwen2.5-coder:14b
save_session: true
repl_prelude: "session:kb"
clients:
  - type: openai-compatible
    name: ollama
    api_base: http://localhost:11434/v1
    api_key: ollama
    models:
      - name: nomic-embed-text:latest
        type: embedding
        default_chunk_size: 1000
        max_batch_size: 100
        max_tokens_per_chunk: 8192
      - name: qwen2.5-coder:14b
        max_input_tokens: 64000
        supports_function_calling: true
```

---

# 3 Create the knowledge base directory

The knowledge base lives in:

```
~/.kb
```

Example structure:

```
~/.kb
  docs/
    index.md
    adr.md
    itil_sre_devops.md
    security_scanning.md
  configs/
    tmux/
      tmux.conf -> ~/.config/tmux/tmux.conf
```

Configs are usually **symlinked**, not copied.

Example:

```
ln -s ~/.config/tmux/tmux.conf ~/.kb/configs/tmux/tmux.conf
```

---

# 4 Initialize RAG

Start aichat:

```
aichat
```

Create a **named RAG index**:

```
.rag kb
```

Choose:

```
embedding model: ollama:nomic-embed-text
chunk size: 1000
chunk overlap: 50
documents: ~/.kb
```

This builds the vector index.

---

# 5 Using the knowledge assistant

Start aichat:

```
aichat
```

Attach the knowledge base:

```
.rag kb
```

Ask questions:

```
what is my tmux prefix key
```

Example response:

```
Your tmux prefix key is set to C-a.
```

---

# 6 Updating the knowledge base

If files inside `.kb` change, rebuild the index:

```
.rebuild rag
```

This updates embeddings.

---

# 7 Useful commands

Show RAG information:

```
.info rag
```

Show sources used for the last answer:

```
.sources rag
```

Add or remove documents:

```
.edit rag-docs
```

---

# 8 Typical workflow

Start development environment:

```
editor .
```

Pane layout:

```
pane 1 → nvim
pane 2 → aichat
```

Then inside aichat:

```
.session kb
.rag kb
```

Ask questions about:

- tmux
- fish
- dotfiles
- documentation

---
