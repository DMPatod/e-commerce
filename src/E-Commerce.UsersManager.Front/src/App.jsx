import React from "react";
import ReactDOM from "react-dom/client";
import UsersPage from "./pages/UsersPage";

const App = () => {
  return (
    <div style={{ backgroundColor: "#D9D9D9" }}>
      App
      <UsersPage />
    </div>
  );
};

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <App />
  </React.StrictMode>
);
