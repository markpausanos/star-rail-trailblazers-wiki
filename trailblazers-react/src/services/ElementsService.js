import axios from "axios";
import config from "./config";

const BASE_URL = `${config.API_URL}/api/Elements`;

const ElementsService = {
  create: (element) => axios.post(BASE_URL, element),
  list: () => axios.get(BASE_URL),
  retrieveById: (id) => axios.get(`${BASE_URL}/${id}`),
  retrieveByName: (name) =>
    axios.get(`${BASE_URL}`, {
      params: {
        name,
      },
    }),
  update: (id, updatedElement) =>
    axios.put(`${BASE_URL}/${id}`, updatedElement),
  delete: (id) => axios.delete(`${BASE_URL}/${id}`),
};

export default ElementsService;
