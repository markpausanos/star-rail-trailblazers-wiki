import { isLocal } from "../utils/destinations";

let apiUrl = null;

if ( isLocal ) {
    apiUrl = 'https://127.0.0.1:8000/api'
}

const config = {
    API_URL: apiUrl
}

export default config;