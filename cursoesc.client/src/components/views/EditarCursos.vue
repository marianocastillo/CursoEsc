<template>
  <div class="container">
    <!-- Botón para abrir el modal alineado a la derecha -->
    <div class="d-flex justify-content-center w-70 mx-auto">
      <h3>Actualiza Registro de Curso</h3>
        
      </div>

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
              <th class="text-center">Acciones</th>
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
                 <img v-if="curso.imagen" :src="curso.imagen" alt="Imagen del curso" style="width: 200px; height: auto;">
              </td>
              <td class="text-center">
                <div class="d-flex justify-content-center gap-1">
                  <button class="btn btn-info btn-sm px-2 py-1" data-toggle="modal" data-target="#squarespaceModal" @click="editarCurso(curso)">
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


    <!-- Modal -->
    <div class="modal fade" id="squarespaceModal" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h3 class="modal-title"></h3>
            <button type="button" class="close" data-dismiss="modal">
              <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="updateCurso">
              <div class="form-group">
                <label for="curso">Nombre del Curso</label>
                <input type="text" class="form-control" id="curso" v-model="curso.nombre" placeholder="Nombre del Curso" />
              </div>

              <div class="form-group">
                <label for="descripcion">Descripción</label>
                <input type="text" class="form-control" id="descripcion" v-model="curso.descripcion" placeholder="Descripción" />
              </div>

              <div class="form-group">
                <label for="categoria">Categoría</label>
                <input type="number" class="form-control" id="iidcategoriacurso" v-model="curso.iidcategoriacurso" placeholder="Categoría" />
              </div>

              <div class="form-group">
                <label for="precio">Precio</label>
                <input type="number" class="form-control" id="precio" v-model="curso.precio" placeholder="Precio" />
              </div>

              <div class="form-group">
                <label for="cupon">Cupón</label>
                <input type="text" class="form-control" id="cupon" v-model="curso.cupon" placeholder="Cupón" />
              </div>

              <div class="form-group">
                <label for="imagen">Imagen</label>
                <input type="file" id="imagen" @change="handleFileUpload" />
                <div v-if="curso.previewImagen" class="mt-2">
                  <img :src="curso.previewImagen" alt="Vista previa" class="img-thumbnail" width="100" />
                </div>
              </div>

              <!-- Checkbox para cambiar estado -->
              <div class="form-check">
                <input type="checkbox"
                       class="form-check-input"
                       id="checkMeOut"
                       v-model="curso.bhabilitado"
                       :true-value="1"
                       :false-value="0" />
                <label class="form-check-label" for="checkMeOut">Status</label>
              </div>

              <!-- Mostrar estado -->
              <div class="mt-3">
                <span v-if="curso.bhabilitado === 1" class="badge bg-success">Activo</span>
                <span v-else class="badge bg-danger">Inactivo</span>
              </div>

              <button type="submit" class="btn btn-primary mt-3" >Guardar</button>
            </form>
          </div>

          <div class="modal-footer">
            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
  const API_URL = "https://localhost:44393/api/Curso";


  import axios from 'axios';
  import { apiService } from "@/services/apiService";

  export default {
    name: "TableView",
    data() {
      return {
        curso: {
          nombre: "",
          descripcion: "",
          iidcategoriacurso: "",
          precio: "",
          cupon: "",
          imagen: undefined,
          previewImagen: null, // Para mostrar la imagen en el frontend
          bhabilitado: 0 // 0 = Inactivo, 1 = Activo
         

        },
        cursos: [],
      };
    },
    methods: {
      handleFileUpload(event) {
        const file = event.target.files[0];
        if (file) {
          this.curso.imagen = file;
          this.curso.previewImagen = URL.createObjectURL(file);
        }
      },


   

      async obtenerCursos() {
        try {
          const response = await apiService.getCursos();
          console.log("Datos recibidos de la API:", response.data);
          this.cursos = response.data;
        } catch (error) {
          console.error("Error al obtener los cursos:", error);
        }
      },
      async updateCurso() {
        try {
          const formData = new FormData();
          formData.append("nombre", this.curso.nombre);
          formData.append("descripcion", this.curso.descripcion);
          formData.append("iidcategoriacurso", this.curso.iidcategoriacurso);
          formData.append("precio", this.curso.precio);
          formData.append("cupon", this.curso.cupon);
          formData.append("bhabilitado", this.curso.bhabilitado);

          // Si se sube una nueva imagen, agregarla al FormData
          if (this.curso.imagen) {
            formData.append("imagen", this.curso.imagen);
          }

          // Enviar la actualización a la API
          const response = await axios.put(`${API_URL}/${this.curso.iidcurso}`, formData, {
            headers: {
              "Content-Type": "multipart/form-data",
            },
          });

          // Verificar la respuesta
          if (response.status === 204) {
            this.obtenerCursos();
            alert("Curso actualizado exitosamente");
          } else {
            alert("Error al actualizar el curso");
          }
        } catch (error) {
          console.error("Error al actualizar el curso:", error);
          alert("Ocurrió un error al intentar actualizar el curso.");
        }
      },


      //async updateCurso() {
      //  try {
      //    const formData = new FormData();
      //    formData.append("nombre", this.curso.nombre);
      //    formData.append("descripcion", this.curso.descripcion);
      //    formData.append("iidcategoriacurso", this.curso.iidcategoriacurso);
      //    formData.append("precio", this.curso.precio);
      //    formData.append("cupon", this.curso.cupon);
      //    formData.append("bhabilitado", this.curso.bhabilitado);

      //    // Si se sube una nueva imagen, agregarla al FormData
      //    if (this.curso.imagen) {
      //      formData.append("imagen", this.curso.imagen);
      //    }

      //    // Enviar la actualización a la API
      //    await axios.put(`/api/Curso/${this.curso.iidcurso}`, formData, {
      //      headers: {
      //        "Content-Type": "multipart/form-data",
      //      },
      //    });

      //    // Recargar los cursos y cerrar el modal
      //    this.obtenerCursos();
      //    alert("Curso actualizado exitosamente");
      //  } catch (error) {
      //    console.error("Error al actualizar el curso:", error);
      //  }
      //},
      //async updateCurso(iidcurso, curso) {
      //  try {
      //    let formData = new FormData();
      //    formData.append("nombre", curso.nombre);
      //    formData.append("descripcion", curso.descripcion);
      //    formData.append("iidcategoriacurso", curso.iidcategoriacurso);
      //    formData.append("precio", curso.precio);
      //    formData.append("cupon", curso.cupon);
      //    formData.append("bhabilitado", curso.bhabilitado);

      //    // Si hay una imagen nueva, la agregamos al formData
      //    if (curso.imagen) {
      //      formData.append("imagen", curso.imagen);
      //    }

      //    await axios.put(`/api/Curso/${iidcurso}`, formData, {
      //      headers: {
      //        "Content-Type": "multipart/form-data",
      //      },
      //    });

      //    // Actualizar la lista local si la API responde correctamente
      //    const index = this.cursos.findIndex(c => c.Iidcurso === iidcurso);
      //    if (index !== -1) {
      //      this.cursos[index] = { ...curso };
      //    }

      //    alert("Curso actualizado exitosamente");
      //  } catch (error) {
      //    console.error("Error al actualizar el curso:", error);
      //  }
      //},


      // Método para editar un curso (llamado desde la vista)
      editarCurso(cursoSeleccionado) {
        this.curso = { ...cursoSeleccionado };
      },

      // Método para realizar la actualización en el formulario
      //async actualizarCurso() {
      //  try {
      //    if (!this.curso.iidcurso) {
      //      console.error("Error: El curso no tiene un ID válido");
      //      return;
      //    }

      //    // Llamar al método updateCurso para actualizar el curso
      //    await this.updateCurso(this.curso.iidcurso, this.curso);

      //    // Resetear el formulario después de la actualización
      //    this.curso = {
      //      nombre: "",
      //      descripcion: "",
      //      iidcategoriacurso: "",
      //      precio: "",
      //      cupon: "",
      //      imagen: null,
      //      previewImagen: null,
      //      bhabilitado: 0,
      //    };
      //  } catch (error) {
      //    console.error("Error al actualizar el curso:", error);
      //  }
      //},








      async eliminarCurso(id) {
        try {
          const confirmDelete = confirm("¿Estás seguro de que quieres eliminar este curso?");
          if (!confirmDelete) return;

          const response = await axios.delete(`https://localhost:44393/api/Curso/${id}`);
          console.log("Curso eliminado exitosamente:", response.data);

          // Recargar la lista de cursos
          this.obtenerCursos();
        } catch (error) {
          console.error("Error al eliminar el curso:", error.response ? error.response.data : error.message);
          alert("Hubo un error al eliminar el curso. Por favor, verifica el servidor.");
        }
      },


      //async guardarCurso() {
      //  try {
      //    const formData = new FormData();
      //    formData.append("nombre", this.curso.nombre);
      //    formData.append("descripcion", this.curso.descripcion);
      //    formData.append("categoria", this.curso.categoria);
      //    formData.append("precio", this.curso.precio);
      //    formData.append("cupon", this.curso.cupon);
      //    formData.append("bhabilitado", this.curso.bhabilitado); // Corregido para enviar el estado
      //    if (this.curso.imagen) {
      //      formData.append("imagen", this.curso.imagen);
      //    }
      //    if (this.curso.iidcurso == 0) {
      //      await apiService.createCurso(formData);
      //    }
      //    else {
      //      console.log(this.curso.iidcurso)
      //      formData.append("iidcurso", this.curso.iidcurso);
      //      await apiService.updateCurso(this.curso.iidcurso, formData);
      //    }


      //    alert("Curso creado exitosamente");

      //    // Resetear formulario
      //    this.curso = {
      //      nombre: "",
      //      descripcion: "",
      //      categoria: "",
      //      precio: "",
      //      cupon: "",
      //      imagen: null,
      //      previewImagen: null,
      //      bhabilitado: 0,
      //    };
      //  } catch (error) {
      //    console.error("Error al crear el curso:", error);
      //  }
      //}
    },
    mounted() {
      this.obtenerCursos();

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

<style scoped>
  .form-check-input {
    margin-right: 5px;
  }

  .img-thumbnail {
    max-height: 100px;
  }
</style>
