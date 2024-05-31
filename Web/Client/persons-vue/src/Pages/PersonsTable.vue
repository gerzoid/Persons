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

const tablesStore = useTablesStore();
const personsStore = usePersonsStore();

var hot = ref(null);
registerAllModules();

const route = useRoute();

personsStore.setTableId(route.params.id);

function handleResize() {
  settings.value.height = window.innerHeight - 30 + "px";
}

onMounted(() => {
  window.addEventListener("resize", handleResize);
  personsStore.openTable().then((response) => {
    settings.value.columns = toRaw(personsStore.columns);
    getDataForPersonsTable();
  });
});

function getDataForPersonsTable() {
  personsStore.getDataFromPersons().then((response) => {
    hot.value.hotInstance.updateData(personsStore.tableData);
    settings.value.width = "100%";
  });
}

var settings = ref({
  licenseKey: "non-commercial-and-evaluation",
  colHeaders: true,
  width: "0px",
  height: "95%",
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
      <div class="table">
        <div style="height: 100%">
          <hot-table ref="hot" :settings="settings" class="persons-table"></hot-table>
        </div>
      </div>
    </Layout>
  </n-spin>
</template>
<style>
.content {
  padding: 20px;
  display: flex;
  flex: auto;
  height: 90vh;
}
.table {
  display: flex;
  flex: 1;
  flex-flow: column;
  min-height: 0;
  min-width: 0;
  padding-right: 30px;
}
.persons-table {
  margin: 20px;
}

.table-link {
  display: contents;
}
</style>
