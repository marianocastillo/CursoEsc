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
                <img :src="curso.imagen" alt="Imagen" class="img-thumbnail" width="50" />
              </td>

            </tr>
          </tbody>
        </table>
      </div>
    </div>


    <!-- Modal -->
    <div class="modal fade" id="squarespaceModal" tabindex="-1" role="dialog" aria-labelledby="modalLabel"
      aria-hidden="true">
      <div class="modal-dialog modal-dialog-centered">
        <div class="modal-content">
          <div class="modal-header">
            <h3 class="modal-title" id="registro"></h3>
            <button type="button" class="close" data-dismiss="modal">
              <span aria-hidden="true">&times;</span><span class="sr-only">Close</span>
            </button>
          </div>
          <div class="modal-body">
            <form @submit.prevent="guardarCurso">
              <div class="form-group">
                <label for="curso">Nombre del Curso</label>
                <input type="text" class="form-control" id="curso" v-model="curso.nombre"
                  placeholder="Nombre del Curso" />
              </div>

              <div class="form-group">
                <label for="descripcion">Descripción</label>
                <input type="text" class="form-control" id="descripcion" v-model="curso.descripcion"
                  placeholder="Descripción" />
              </div>

              <div class="form-group">
                <label for="categoria">Categoría</label>
                <input type="number" class="form-control" id="iidcategoriacurso" v-model="curso.iidcategoriacurso"
                  placeholder="Categoría" />
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
                  <img v-if="curso.ImagenUrl" :src="curso.ImagenUrl" alt="Imagen del curso" class="curso-imagen">
                </div>
              </div>

              <!-- Checkbox para cambiar estado -->
              <div class="form-check">
                <input type="checkbox" class="form-check-input" id="checkMeOut" v-model="curso.bhabilitado"
                  :true-value="1" :false-value="0" />
                <label class="form-check-label" for="checkMeOut">Status</label>
              </div>

              <!-- Mostrar estado -->
              <div class="mt-3">
                <span v-if="curso.bhabilitado === 1" class="badge bg-success">Activo</span>
                <span v-else class="badge bg-danger">Inactivo</span>
              </div>

              <button type="submit" class="btn btn-primary mt-3">Guardar</button>
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
import axios from "axios";
const API_URL = "https://localhost:44393/api/Curso";
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
      this.curso.imagen = file;

      // Mostrar una vista previa de la imagen
      if (file) {
        const reader = new FileReader();
        reader.onload = (e) => {
          this.curso.previewImagen = e.target.result;
        };
        reader.readAsDataURL(file);
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




    async guardarCurso() {
      try {
        const formData = new FormData();
        // Usa exactamente los mismos nombres que espera el modelo en C#
        formData.append("Nombre", this.curso.nombre);
        formData.append("Descripcion", this.curso.descripcion);
        formData.append("Iidcategoriacurso", Number(this.curso.iidcategoriacurso));
        formData.append("Precio", Number(this.curso.precio));
        formData.append("Cupon", this.curso.cupon);
        formData.append("Bhabilitado", Number(this.curso.bhabilitado));

        if (this.curso.imagen) {
          formData.append("Imagen", this.curso.imagen);
        }

        // Depuración: imprime el contenido de formData
        for (let pair of formData.entries()) {
          console.log(`${pair[0]}: ${pair[1]}`);
        }

        let response;
        if (this.curso.iidcurso && Number(this.curso.iidcurso) !== 0) {
          // Actualización: se usa PUT y se pasa el ID en la URL
          response = await axios.put(`${API_URL}/${this.curso.iidcurso}`, formData, {
            headers: { "Content-Type": "multipart/form-data" }
          });
          if (response.status === 204) {
            alert("Curso actualizado exitosamente");
          } else {
            alert("Error al actualizar el curso");
          }
        } else {
          // Creación: se usa POST a la URL base sin ID
          response = await axios.post(API_URL, formData, {
            headers: { "Content-Type": "multipart/form-data" }
          });
          if (response.status === 201) {
            alert("Curso creado exitosamente");
            
          } else {
            alert("Error al crear el curso");
          }
        }

        // Recargar la lista de cursos
        await this.obtenerCursos();

        // Resetear formulario
        this.curso = {
          nombre: "",
          descripcion: "",
          iidcategoriacurso: "",
          precio: "",
          cupon: "",
          imagen: null,
          previewImagen: null,
          bhabilitado: 0
        };
      } catch (error) {
        console.error("Error al crear el curso:", error);
      }
    },



    mounted() {
      this.obtenerCursos();

    }
  }
}


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


.curso-card {
  border: 1px solid #ccc;
  padding: 10px;
  margin: 10px;
  border-radius: 5px;
  width: 300px;
  text-align: center;
}

.curso-imagen {
  width: 100%;
  height: auto;
  max-height: 200px;
  object-fit: cover;
  border-radius: 5px;
}
</style>
