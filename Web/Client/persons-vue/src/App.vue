<script setup>
import { Locked, User } from "@vicons/carbon";
import { NCard, NIcon, NForm, NFormItem, NInput, NButton } from "naive-ui";

var model = {
  email: null,
  password: null,
};
var loading = false;
var rules = {};
var login = false;
</script>

<template>
  <div class="login">
    <n-card>
      <h2>Вход в систему</h2>
      <n-form class="login-form" :model="model" :rules="rules" ref="form">
        <n-form-item prop="username">
          <n-input
            v-model="model.email"
            placeholder="Email"
            type="email"
            :prefix-icon="User"
          >
            <template #prefix>
              <n-icon :component="User"></n-icon>
            </template>
          </n-input>
        </n-form-item>
        <n-form-item prop="password">
          <n-input v-model="model.password" placeholder="Password" type="password">
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
            native-type="submit"
            block
            >Войти</n-button
          >
        </n-form-item>
        <a class="forgot-password" href="#">Забыли пароль?</a>
      </n-form>
    </n-card>

    <!--    <n-card>
      <h2>Вход в систему</h2>
      <n-form
        class="login-form"
        :model="model"
        :rules="rules"
        ref="form"
        @submit.native.prevent="login"
      >
        <n-form-item prop="username">
          <n-input
            v-model="model.email"
            placeholder="Email"
            type="email"
            :prefix-icon="User"
          ></n-input>
        </n-form-item>
        <n-form-item prop="password">
          <n-input
            v-model="model.password"
            placeholder="Password"
            type="password"
            :prefix-icon="Lock"
          ></n-input>
        </n-form-item>
        <n-form-item>
          <n-button
            :loading="loading"
            class="login-button"
            type="primary"
            native-type="submit"
            block
          >Войти</n-button>
        </n-form-item>
        <a class="forgot-password" href="#">Забыли пароль?</a>
      </n-form>
    </n-card>-->
  </div>
</template>
<style scoped>
.logo {
  height: 6em;
  padding: 1.5em;
  will-change: filter;
  transition: filter 300ms;
}
.logo:hover {
  filter: drop-shadow(0 0 2em #646cffaa);
}
.logo.vue:hover {
  filter: drop-shadow(0 0 2em #42b883aa);
}
</style>
