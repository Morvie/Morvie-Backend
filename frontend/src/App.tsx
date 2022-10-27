import React, { useEffect, useState } from "react";
import logo from "./logo.svg";
import "./App.css";
import KeyCloakService from "./security/KeyCloakService";
import { useAxios } from "./hooks/useAxios";

function logout() {
  KeyCloakService.CallLogout();
}

export function CallApi() {
  const axiosInstance = useAxios("http://localhost:5100/" ?? "");
  const [readyForApi, setReadyForApi] = useState(false);
  const [data, setData] = useState(undefined);
  useEffect(() => {
    if (!axiosInstance.current || !readyForApi) return;

    console.log("Initiating the API call...");
    axiosInstance.current
      .get("/gateway/review/93a87c60-7e94-48e9-8bec-5a23b81f8631")
      .then((res) => setData(res.data))
      .catch((err) => setData(err));

    setReadyForApi(false);
  }, [readyForApi, axiosInstance]);

}

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <img src={logo} className="App-logo" alt="logo" />
        <p>
          Edit <code>src/App.tsx</code> and save to reload.
        </p>
        <p>Welcome {KeyCloakService.GetUserName()}</p>
        <p>Roles: {KeyCloakService.GetUserRoles()?.join(" ")}</p>
        <button onClick={logout}>Logout</button>
         <button type="button" onClick={CallApi}>
        Call API
      </button>
      </header>
    </div>
  );
}

export default App;
