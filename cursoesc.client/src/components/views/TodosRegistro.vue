<template>
  <div class="d-flex justify-content-center w-70 mx-auto">
    <h3>Registro de Curso</h3>

  </div>
  <div class="container">
    <div class="sidebar-container">
      <div class="table-responsive">
        <table class="table table-striped table-bordered">
          <thead class="thead-dark">
            <tr>
              <th>ID</th>
              <th>Nombre</th>
              <th>Descripción</th>
              <th>IidCategoríaCurso</th>
              <th>Precio</th>
              <th>Cupon</th>
              <th>Status</th>
              <th>Imagen</th>

            </tr>
          </thead>
          <tbody>
            <tr v-for="curso in cursos" :key="curso.iidcurso">
              <td>{{ curso.iidcurso }}</td>
              <td>{{ curso.nombre }}</td>
              <td>{{ curso.descripcion }}</td>
              <td>{{ curso.iidcategoriacurso }}</td>
              <td>${{ curso.precio }}</td>
              <td>{{ curso.cupon }}</td>
              <td>
                <span v-if="curso.bhabilitado === 1" class="badge bg-success">Activo</span>
                <span v-else class="badge bg-danger">Inactivo</span>
              </td>
              <td>
                <img v-if="curso.ImagenUrl" :src="curso.ImagenUrl" alt="Imagen del curso" style="width: 200px; height: auto;">
              </td>

            </tr>
          </tbody>
        </table>
      </div>
    </div>
  </div>
</template>


<script>
  import { apiService } from "@/services/apiService"; // Importa la API

  export default {
    name: "TodosRegistro",
    data() {
      return {
        cursos: [], // Almacena los cursos
      };
    },
    methods: {
      async obtenerCursos() {
        try {
          const response = await apiService.getCursos();
          console.log("Datos recibidos de la API:", response.data); // Verifica si la API responde correctamente
          this.cursos = response.data;
        } catch (error) {
          console.error("Error al obtener los cursos:", error);
        }
      }
    },
    mounted() {
      this.obtenerCursos(); // Llama a la API al cargar el componente
    },
  };
</script>

<style>
  /* Estilos opcionales */
  .table {
    max-width: 90%;
  }
</style>


<style scoped>
  .sidebar-container {
    padding: 10px;
    background-color: #f8f9fa;
    border-radius: 8px;
  }

  .table-responsive {
    overflow-x: auto;
    padding: 10px;
    border-radius: 8px;
    background-color: white;
    box-shadow: 0 2px 5px rgba(0, 0, 0, 0.1);
  }
</style>
