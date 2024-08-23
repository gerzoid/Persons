import axios from 'axios';
import { useRouter } from "vue-router";

export const axio = axios.create({
    baseURL : 'http://localhost:5264',
    //baseURL : 'http://localhost:5000',
    //baseURL : 'http://ovz1.gerztrue-gmail-c.ndzjp.vps.myjino.ru:49293'
})

axio.interceptors.request.use(
    (config) => {
      if (localStorage.access_token) {
        config.headers.authorization = `Bearer ${localStorage.access_token}`;
      }
      return config;
    },
    (error) => {
      //Этот блок кода срабатывает только тогда, когда ошибка отправки запроса с фронта
      console.log(error);
    }
  );

  axio.interceptors.response.use(
    (config) => {
      if (localStorage.access_token) {
        config.headers.authorization = `Bearer ${localStorage.access_token}`;
      }

      return config;
    },
    (error) => {
      //Этот блок кода срабатывает когда прилетает ошибка с бэка
      if (error.response.data.message === "Token has expired") {
        axio.post(
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

      // if (error.response.status === 401) {
      //   console.log('not logged!');
      // }
      return Promise.reject(error); // Передаем ошибку дальше
    }
  );