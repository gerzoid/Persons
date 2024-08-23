import { createApp } from 'vue'
import './style.css'
import { createRouter, createWebHistory } from 'vue-router'
import { createPinia } from 'pinia'
import App from './Pages/App.vue'
import { useAuthStore } from "./stores/authStore";

let Pinia = createPinia();
var apps = createApp(App).use(Pinia);

const authStore = useAuthStore();

if (authStore.isAuthenticated && authStore.isAdmin==null) {
  var r = await authStore.fetchUser(authStore.token);
}

const authGuard = (to, from, next) => {
  console.log(authStore.isAuthenticated);
  if (authStore.isAuthenticated) {
      next();
    } else {
      next("/login")
    }
  };

  const routes = [
    { path: '/', name:'Main', component: ()=>import('./components/HelloWorld.vue') },
    { path: '/login', name:'Login', component:()=>import('./Pages/Login.vue')},
    { path: '/admin/table/add', name:'AddTable', component: ()=>import('./Pages/Admin/AddTable.vue'), beforeEnter: authGuard },
    { path: '/admin/table/edit/:tableId', name:'EditTable', component:()=>import('./Pages/Admin/EditTable.vue'), beforeEnter: authGuard },
    { path: '/tables', name:'Tables', component: ()=>import('./Pages/Tables.vue'),  beforeEnter: authGuard, },
    { path: '/table/:tableId', name:'PersonsTable', component: ()=>import('./Pages/PersonsTable.vue'), beforeEnter: authGuard },
];
const router = createRouter({
    routes,
    history: createWebHistory()
});

apps.use(router).mount('#app');