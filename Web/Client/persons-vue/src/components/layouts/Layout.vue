<script setup>
import VerticalMenu from "../menu/VerticalMenu.vue";
import HorizontalMenu from "../menu/HorizontalMenu.vue";
import { NLayout } from "naive-ui";
import { useAuthStore } from "../../stores/authStore";
import { Refresh } from "@vicons/ionicons5";

const authStore = useAuthStore();
function logout() {
  authStore.logout();
  location.reload();
}
</script>

<template>
  <div class="main">
    <router-view> </router-view>
    <n-layout>
      <button @click="logout">Выйти</button>
      <!--<HorizontalMenu></HorizontalMenu>-->
      <n-layout has-sider style="height: 100%">
        <VerticalMenu></VerticalMenu>
        <slot></slot>
      </n-layout>
    </n-layout>
  </div>
</template>
<style>
.n-layout-header,
.n-layout-footer {
  background: rgba(128, 128, 128, 0.2);
}
div.main {
  height: 100vh;
  display: flex;
}

.n-layout-sider {
  background: rgba(128, 128, 128, 0.3);
}

.n-layout-content {
  background: rgba(128, 128, 128, 0.4);
}
</style>
