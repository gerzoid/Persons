import { createApp } from 'vue'
import './style.css'
import { createRouter, createWebHistory } from 'vue-router'
import { createPinia } from 'pinia'

import Login from './Pages/Login.vue'
import Weather from './Pages/Weather.vue'
import App from './App.vue'


let Pinia = createPinia();

const routes = [
    { path: '/login', component: Login },
    { path: '/', component: Weather },
    { path: '/home', component: App },
    { path: '/weather', component: Weather }
];

const router = createRouter({
    routes,
    history: createWebHistory()
});

createApp(App).use(Pinia).use(router).mount('#app');