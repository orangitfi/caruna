import { useState } from "react";
import "./App.css";

function App() {
  const [count, setCount] = useState(0);

  return (
    <div className="App">
      <header className="App-header">
        <h1>🐳 Example React Container</h1>
        <p>
          This is a simple React app for testing Docker container security
          scanning
        </p>

        <div className="card">
          <button onClick={() => setCount((count) => count + 1)}>
            Count is {count}
          </button>
        </div>

        <div className="info">
          <h2>✅ Container is running!</h2>
          <p>If you can see this page, the container is working correctly.</p>
        </div>

        <div className="features">
          <h3>Features to test:</h3>
          <ul>
            <li>✅ React 18</li>
            <li>✅ Vite build tool</li>
            <li>✅ Hot Module Replacement</li>
            <li>✅ Multi-stage Docker build</li>
            <li>🔍 Security scanning with Grype/Syft</li>
          </ul>
        </div>
      </header>
    </div>
  );
}

export default App;
