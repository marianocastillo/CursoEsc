import axios from "axios";

const API_URL = "https://localhost:44393/api/Curso";

const apiService = {
  // Obtener todos los cursos
  getCursos() {
    return axios.get(API_URL);
  },

  // Obtener un curso por su ID
  getCurso(id) {
    return axios.get(`${API_URL}/${id}`);
  },

  // Crear un nuevo curso
  createCurso(curso) {
    return axios.post(API_URL, curso, {
      headers: {
        'Content-Type': 'application/json',
      },
    });
  },

  // Actualizar un curso existente
  updateCurso(id, data) {
    return axios.put(`${API_URL}/${id}`, data);
  },

  // Eliminar un curso
  deleteCurso(id) {
    return axios.delete(`${API_URL}/${id}`);
  },
};

export { apiService };
