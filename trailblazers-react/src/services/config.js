import { isLocal } from "../utils/destinations";

let apiUrl = null;

if (isLocal) {
  apiUrl = "https://localhost:8000";
}

const config = {
  API_URL: apiUrl,
};

export default config;
