import React from "react";
import SocketList from "../components/socketList";

const UsersPage = () => {
  return (
    <div style={{ backgroundColor: "#90CFF8" }}>
      <SocketList url="TempUrl" />
      <div>
        <button>New User</button>
      </div>
    </div>
  );
};

export default UsersPage;
