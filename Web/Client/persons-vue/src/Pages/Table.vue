<script setup>
import { onMounted, ref } from "vue";
import Layout from "../components/layouts/Layout.vue";
import { useRoute } from "vue-router";
import { NSpin } from "naive-ui";
import { useTablesStore } from "../stores/tablesStore";

const show = ref(true);
const tablesStore = useTablesStore();
var tables = ref([]);

const route = useRoute();
const id = route.params.id;

onMounted(() => {
  tablesStore.getTable(3).then((response) => {
    console.log(response);
  });
});
</script>

<template>
  <router-view> </router-view>
  <n-spin
    :show="show"
    size="large"
    stroke="white"
    content-style="color:white;"
    stroke-width="30"
  >
    <template #description><p style="color: white">Загрузка...</p></template>
    <Layout>
      <div class="content">Это таблица id={{ id }}</div>
    </Layout>
  </n-spin>
</template>
<style>
.content {
  padding: 20px;
  display: flex;
  flex: auto;
}

.table-link {
  display: contents;
}
</style>
