import Keycloak from "keycloak-js";

const keycloakInstance = new Keycloak();

/**
 * Initializes Keycloak instance and calls the provided callback function if successfully authenticated.
 *
 * @param onAuthenticatedCallback
 */
const initKeycloak = (onAuthenticatedCallback) => {
  keycloakInstance
  .init({
    onLoad: 'check-sso',
    pkceMethod: 'S256'
  })
  .then((authenticated) => {
     if (!authenticated) {
        console.log("user is not authenticated..!");
     }
    onAuthenticatedCallback();
  })
  .catch(console.error);
};

const KeyCloakService = {
  initKeycloak,
};

export default KeyCloakService;

