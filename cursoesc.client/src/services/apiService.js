
import axios from "axios";

const API_URL = "https://localhost:7086/api/Curso"; // URL base de la API

export const apiService = {
  getCursos() {
    return axios.get(API_URL); // Aquí no necesitas agregar "/Curso" porque ya está en API_URL
  },
  getCurso(id) {
    return axios.get(`${API_URL}/${id}`);
  },
  createCurso(data) {
    return axios.post(API_URL, data);
  },
  updateCurso(id, data) {
    return axios.put(`${API_URL}/${id}`, data);
  },
  deleteCurso(id) {
    return axios.delete(`${API_URL}/${id}`);
  },
};
