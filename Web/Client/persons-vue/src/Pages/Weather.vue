<script setup>
import { ref } from "vue";
import api from "../utils/api";

var response = ref(null);

var retr = api.get("/WeatherForecast").then((ret) => {
  response.value = ret.data;
});
</script>

<template>
  {{ response }}
  <router-view> </router-view>
</template>
<style scoped></style>
