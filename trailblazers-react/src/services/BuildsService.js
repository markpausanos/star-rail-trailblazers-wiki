import axios from 'axios';
import config from './config';

const BASE_URL = `${config.API_URL}/Builds`;

const BuildsService = {
    create: (build) => axios.post(BASE_URL, build),
    list: () => axios.get(BASE_URL),
    update: (id, updatedBuild) => axios.put(`${BASE_URL}/${id}`, updatedBuild),
    like: (id) => axios.post(`${BASE_URL}/${id}/like`),
    unlike: (id) => axios.post(`${BASE_URL}/${id}/unlike`),
    delete: (id) => axios.delete(`${BASE_URL}/${id}`)
}

export default BuildsService;