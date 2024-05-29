<script setup>
import { HotTable } from "@handsontable/vue3";
import "handsontable/dist/handsontable.full.min.css";
import { registerAllModules } from "handsontable/registry";
import { onMounted, ref, toRaw } from "vue";
import Layout from "../components/layouts/Layout.vue";
import { useRoute } from "vue-router";
import { NSpin } from "naive-ui";
import { useTablesStore } from "../stores/tablesStore";
import { usePersonsStore } from "../stores/personsStore";

//const show = ref(true);
const tablesStore = useTablesStore();
const personsStore = usePersonsStore();

const route = useRoute();
const id = route.params.id;

onMounted(() => {
  personsStore.openTable(id).then((response) => {
    settings.value.columns = toRaw(personsStore.columns);
    settings.value.width = "100%";
  });
});

var settings = ref({
  licenseKey: "non-commercial-and-evaluation",
  colHeaders: true,
  width: "0px",
  height: "100%",
  manualColumnResize: true,
  columnSorting: true,
  wordWrap: false,
  autoColumnSize: true,
});
</script>

<template>
  <router-view> </router-view>
  <n-spin
    :show="personsStore.loading"
    size="large"
    stroke="white"
    content-style="color:white;"
    :stroke-width="30"
  >
    <template #description><p style="color: white">Загрузка...</p></template>
    <Layout>
      <hot-table ref="hot" :settings="settings" class="persons-table"></hot-table>
    </Layout>
  </n-spin>
</template>
<style>
.content {
  padding: 20px;
  display: flex;
  flex: auto;
}
.persons-table {
  margin: 10px;
}

.table-link {
  display: contents;
}
</style>
