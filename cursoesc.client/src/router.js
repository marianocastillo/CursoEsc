import { createRouter, createWebHistory } from 'vue-router';
import TodosRegistro from './components/views/TodosRegistro.vue';
import TableView from './components/views/TableView.vue';
//import Edit from './components/views/Edit.vue'; // Agregamos la vista Edit.vue

const router = createRouter({
  history: createWebHistory(),
  routes: [
    { path: '/', redirect: '/registro' }, // Redirige la ruta base a /view
    { path: '/view', name: "view", component: TableView },
    { path: '/registro', name: "TodosRegistro", component: TodosRegistro },
    //{ path: '/edit', name: "edit", component: Edit }, // Agregamos la ruta de Orders
  ]
});

export default router;
