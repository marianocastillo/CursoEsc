import { createRouter, createWebHistory } from 'vue-router';
import TodosRegistro from './components/views/TodosRegistro.vue';
import TableView from './components/views/TableView.vue';
import EditarCursos from './components/views/EditarCursos.vue'; // Agregamos la vista Edit.vue

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', redirect: '/registro' }, // Redirige la ruta base a /view
    { path: '/registro', name: "TableView", component: TableView },
    { path: '/home', name: "TodosRegistro", component: TodosRegistro },
    { path: '/edit', name: "EditarCursos", component: EditarCursos }, // Agregamos la ruta de Orders
  ]
});

export default router;
