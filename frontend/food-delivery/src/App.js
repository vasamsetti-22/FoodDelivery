import "./styles.css";
import reactLogo from "./reactLogo.png";

export default function App() {
  return (
    <div className="app">
      <h1>Image in project</h1>
      <img src={reactLogo} alt="react logo" />

      <h1>Image from google</h1>
      <img
        src="https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/React-icon.svg/1200px-React-icon.svg.png"
        alt="react logo"
      />
      <h1>Background image</h1>
      <div
        className="background-image"
        style={{
          backgroundImage:
            "url(https://upload.wikimedia.org/wikipedia/commons/thumb/a/a7/React-icon.svg/1200px-React-icon.svg.png)",
        }}
      >
        Overlay text
      </div>
    </div>
  );
}
