import axios from "axios";
import { useRouter, useRoute } from "vue-router";
//import {router} from "vue-router";

//var router = useRouter();

const api = axios.create({
  baseURL : 'http://localhost:5264',
  
});

//start request
api.interceptors.request.use(
  (config) => {
    if (localStorage.access_token) {
      config.headers.authorization = `Bearer ${localStorage.access_token}`;
    }
    //Надо возвращать конфиг после его модификации
    return config;
  },
  (error) => {
    //Этот блок кода срабатывает только тогда, когда ошибка отправки запроса с фронта
    console.log(error);
  }
);
//end request

//start response
api.interceptors.response.use(
  (config) => {
    config.headers['Access-Control-Allow-Origin'] = '*';
    if (localStorage.access_token) {
      config.headers.authorization = `Bearer ${localStorage.access_token}`;
    }

    return config;
  },
  (error) => {
    //Этот блок кода срабатывает когда прилетает ошибка с бэка

    if (error.response.data.message === "Token has expired") {
      axios
        .post(
          "api/auth/refresh",
          {},
          {
            headers: {
              authorization: `Bearer ${localStorage.access_token}`,
            },
          }
        )
        .then((response) => {
          localStorage.access_token = response.data.access_token;
          //Делаем повторный запрос на получение данных с новым токеном
          //чтобы вручную не обновлять страницу
          error.config.headers.authorization = `Bearer ${response.data.access_token}`;

          return api.request(error.config);
        });
    }

    if (error.response.status === 401) {
      console.log('not logged');
      //router.push("/login");
    }
  }
);
export default api;
