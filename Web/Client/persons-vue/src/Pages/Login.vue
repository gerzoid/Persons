<script setup>
import { ref } from "vue";
import { useAuthStore } from "../stores/authStore";
import { useRouter } from "vue-router";
import { NCard, NForm, NFormItem, NInput, NButton, NIcon } from "naive-ui";
import { User, Locked } from "@vicons/carbon";
import api from "../Utils/api";

const router = useRouter();
const authStore = useAuthStore();

var model = ref({
  username: "",
  password: "",
});

let loading = ref(false);
let rules = ref({});

const login = async () => {
  loading.value = true;
  try {
    const response = await api.post("api/Identity/login", {
      username: model.value.username,
      password: model.value.password,
    });
    localStorage.setItem("access_token", response.data.token);
    console.log(authStore);
    authStore.setUser(response.data);
    router.push("/home");
  } catch (error) {
    console.error(error);
  } finally {
    loading.value = false;
  }
};
</script>

<template>
  <div class="login">
    <n-card>
      <h2>Вход в систему</h2>
      <n-form class="login-form" :rules="rules">
        <n-form-item prop="username">
          <n-input v-model:value="model.username" placeholder="Имя">
            <template #prefix>
              <n-icon :component="User"></n-icon>
            </template>
          </n-input>
        </n-form-item>
        <n-form-item prop="password">
          <n-input v-model:value="model.password" placeholder="Password" type="password">
            <template #prefix>
              <n-icon :component="Locked"></n-icon>
            </template>
          </n-input>
        </n-form-item>
        <n-form-item>
          <n-button
            :loading="loading"
            class="login-button"
            type="primary"
            @click="login"
            block
          >
            Войти
          </n-button>
        </n-form-item>
        <a class="forgot-password" href="#">Забыли пароль?</a>
      </n-form>
    </n-card>
  </div>
</template>
