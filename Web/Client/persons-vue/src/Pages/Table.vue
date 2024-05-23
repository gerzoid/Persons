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

var settings = ref({
  licenseKey: "non-commercial-and-evaluation",
  columns: toRaw(fileStore.fileInfo.columns),
  colHeaders: true,
  width: "100%",
  height: "100%",
  manualColumnResize: true,
  columnSorting: true,
  wordWrap: false,
  autoColumnSize: true,
  cells: function (row, col, prop) {
    var cellProperties = {};
    if (hot.value.hotInstance.getDataAtCell(row, fileStore.fileInfo.countColumns) == true)
      cellProperties.className = "deleted";
    return cellProperties;
  },  
    items: {
      stat: {
        name() {
          return "Статистика";
        },
        submenu: {
          items: [
            {
              key: "stat:cm_group",
              name: "Группировать",
              callback(key, selection, clickEvent) {
                fileStore.modal.dopInfo = {
                  column: fileStore.fileInfo.columns[selection[0].start.col].data,
                };
                fileStore.activeModalComponent = "Group";
              },
            },
            {
              key: "stat:cm_countunique",
              name: "Количество уникальных записей по столбцу",
              callback(key, selection, clickEvent) {
                fileStore.modal.dopInfo = {
                  column: fileStore.fileInfo.columns[selection[0].start.col].data,
                };
                fileStore.activeModalComponent = "CountUnique";
              },
            },
            {
              key: "stat:cm_countvalue",
              name: "Количество записей со значением в выделеннной ячейке",
              callback(key, selection, clickEvent) {
                fileStore.modal.dopInfo = {
                  value: hot.value.hotInstance.getDataAtCell(
                    selection[0].start.row,
                    selection[0].start.col
                  ),
                  column: fileStore.fileInfo.columns[selection[0].start.col].data,
                };
                fileStore.activeModalComponent = "CountValue";
              },
            },
          ],
        },
      },
    },
});


</script>

<template>
  <router-view> </router-view>
  <n-spin
    :show="show"
    size="large"
    stroke="white"
    content-style="color:white;"
    :stroke-width="30"
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
