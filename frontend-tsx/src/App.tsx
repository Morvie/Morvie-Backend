import React from 'react';
import logo from './logo.svg';
import './App.css';
import KeyCloakService from './security/KeyCloakService';

function logout(){
  KeyCloakService.CallLogout();
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
      </header>
    </div>
  );
}

export default App;
