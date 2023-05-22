import axios from 'axios';
import config from './config';

const BASE_URL = `${config.API_URL}/Ornaments`;

const OrnamentsService = {
    create: (ornament) => axios.post(BASE_URL, ornament),
    list: () => axios.get(BASE_URL),
    retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
    retrieveByName: (name) => axios.get(`${BASE_URL}`, {
        params: {
            name
        }
    }),
    update: (id, updatedOrnament) => axios.put(`${BASE_URL}/${id}`, updatedOrnament),
    delete: (id) => axios.delete(`${BASE_URL}/${id}`)
}

export default OrnamentsService;