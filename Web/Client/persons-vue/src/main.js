import { createApp } from 'vue'
import './style.css'
import { createRouter, createWebHistory } from 'vue-router'
import { createPinia } from 'pinia'
import App from './Pages/App.vue'
import { useAuthStore } from "./stores/authStore";

let Pinia = createPinia();
var apps = createApp(App).use(Pinia);

const authStore = useAuthStore();

const authGuard = (to, from, next) => {
    if (authStore.isAuthenticated) {
      next();
    } else {
      next("/login")
    }
  };

  const routes = [
    { path: '/login', name:'Login', component:()=>import('./Pages/Login.vue')},
    { path: '/admin/table/add', name:'AddTable', component: ()=>import('./Pages/Admin/AddTable.vue'), beforeEnter: authGuard },
    { path: '/admin/table/edit/:tableId', name:'EditTable', component:()=>import('./Pages/Admin/EditTable.vue'), beforeEnter: authGuard },
    { path: '/tables', name:'Tables', component: ()=>import('./Pages/Tables.vue'),  beforeEnter: authGuard },
    { path: '/table/:id', name:'PersonsTable', component: ()=>import('./Pages/PersonsTable.vue'), beforeEnter: authGuard },
];
const router = createRouter({
    routes,
    history: createWebHistory()
});

apps.use(authStore);
apps.use(router).mount('#app');