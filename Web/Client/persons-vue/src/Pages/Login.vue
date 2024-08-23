<script setup>
import { ref } from "vue";
import { useAuthStore } from "../stores/authStore";
import { useRouter } from "vue-router";
import { NCard, NForm, NFormItem, NInput, NButton, NIcon } from "naive-ui";
import { User, Locked } from "@vicons/carbon";
import api from "../utils/api";

const router = useRouter();
const authStore = useAuthStore();

function login() {
  authStore.login().then(() => {
    router.push("/tables");
    //router.push("/");
  });
}

let rules = ref({});
</script>

<template>
  <div style="display: flex">
    <div class="login">
      <n-card class="login-card">
        <h2>Вход в систему</h2>
        <n-form class="login-form" :rules="rules">
          <n-form-item prop="username">
            <n-input v-model:value="authStore.model.username" placeholder="Имя">
              <template #prefix>
                <n-icon :component="User"></n-icon>
              </template>
            </n-input>
          </n-form-item>
          <n-form-item prop="password">
            <n-input
              v-model:value="authStore.model.password"
              placeholder="Password"
              type="password"
            >
              <template #prefix>
                <n-icon :component="Locked"></n-icon>
              </template>
            </n-input>
          </n-form-item>
          <n-form-item>
            <n-button
              :loading="authStore.loading"
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
  </div>
</template>
<style scoped>
.login {
  margin: 0 auto;
  padding: 2rem;
  text-align: center;
  display: flex;
  justify-content: center;
}
</style>
