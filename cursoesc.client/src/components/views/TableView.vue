<template>
  <div class="container">
    <!-- Botón para abrir el modal alineado a la derecha -->
    <div class="d-flex justify-content-end w-70 mx-auto">
      <button class="btn btn-primary mb-2 me-2" data-toggle="modal" data-target="#squarespaceModal">
        Registrar Curso Nuevo
      </button>
    </div>

    <div class="sidebar-container">
      <div class="table-responsive">
        <table class="table table-striped table-bordered">
          <thead class="thead-dark">
            <tr>
              <th>ID</th>
              <th>Nombre</th>
              <th>Descripción</th>
              <th>Categoría</th>
              <th>Precio</th>
              <th>Cupon</th>
              <th>Status</th>
              <th>Imagen</th>
              <th class="text-center">Acciones</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="curso in cursos" :key="curso.iidcurso">
              <td>{{ curso.iidcurso }}</td>
              <td>{{ curso.nombre }}</td>
              <td>{{ curso.descripcion }}</td>
              <td>{{ curso.categoria }}</td>
              <td>${{ curso.precio }}</td>
              <td>{{ curso.cupon }}</td>
              <td>
                <span v-if="curso.bhabilitado === 1" class="badge bg-success">Activo</span>
                <span v-else class="badge bg-danger">Inactivo</span>
              </td>
              <td>
                <img :src="curso.imagen" alt="Imagen" class="img-thumbnail" width="50" />
              </td>
              <td class="text-center">
                <div class="d-flex justify-content-center gap-1">
                 <button class="btn btn-info btn-sm px-2 py-1" data-toggle="modal" data-target="#squarespaceModal">
                    <i class="bi bi-pencil"></i>
                  </button>
                  <button class="btn btn-danger btn-sm px-2 py-1" @click="eliminarCurso(curso.iidcurso)">
                    <i class="bi bi-trash"></i>
                  </button>
                </div>
              </td>
            </tr>
          </tbody>
        </table>
      </div>
    </div>

    <!-- Modal centrado en la pantalla -->
    <div class="modal fade" id="squarespaceModal" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h3 class="modal-title" id="registro">Registro</h3>
            <button type="button" class="close" data-dismiss="modal">
              <span aria-hidden="true">×</span><span class="sr-only">Close</span>
            </button>
          </div>
          <div class="modal-body">
            <form>
              <div class="form-group">
                <label for="curso">Nombre del Curso</label>
                <input type="text" class="form-control" id="curso" placeholder="Nombre del Curso">
              </div>
              <div class="form-group">
                <label for="descripción">Descripción</label>
                <input type="text" class="form-control" id="descripción" placeholder="Descripción">
              </div>

              <div class="form-group">
                <label for="categoría">Categoría</label>
                <input type="text" class="form-control" id="categoría" placeholder="Categoría">
              </div>

              <div class="form-group">
                <label for="precio">Precio</label>
                <input type="text" class="form-control" id="precio" placeholder="Precio">
              </div>

              <div class="form-group">
                <label for="cupon">Cupon</label>
                <input type="text" class="form-control" id="cupon" placeholder="Cupon">
              </div>

              <div class="form-group">
                <label for="imagen">Imagen</label>
                <input type="file" id="Imagen">

              </div>
              <div class="form-check">
                <input type="checkbox" class="form-check-input" id="checkMeOut">
                <label class="form-check-label" for="checkMeOut">Status</label>
              </div>
              <button type="submit" class="btn btn-primary mt-3">Submit</button>
            </form>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
            <button type="button" class="btn btn-danger">Delete</button>
            <button type="button" class="btn btn-success">Save</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>


<script>
  import { apiService } from "@/services/apiService"; // Importa la API

  export default {
    name: "TableView",
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
