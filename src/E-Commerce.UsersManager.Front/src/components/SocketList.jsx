import React, { useState } from "react";

const SocketList = (props) => {
  var { url } = props;

  const [users, setUsers] = useState([]);

  return (
    <div style={{ backgroundColor: "#F1C886" }}>
      <div>{url}</div>
      {users.map((item, index) => {
        return <div key={index}>{index}</div>;
      })}
    </div>
  );
};

export default SocketList;
