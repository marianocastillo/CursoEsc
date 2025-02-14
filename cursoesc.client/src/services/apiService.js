import axios from "axios";

const API_URL = "https://localhost:7086/api/Curso";  // Asegura que este endpoint es correcto

export const apiService = {
  getCursos() {
    return axios.get(API_URL); // Ahora sí apunta a "/api/Curso"
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
