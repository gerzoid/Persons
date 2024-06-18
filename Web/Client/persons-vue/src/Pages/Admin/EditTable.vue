<script setup>
import { onMounted, ref } from "vue";
import Layout from "../../components/layouts/Layout.vue";
import FormTable from "../../components/table/FormTable.vue";
import { useTablesStore } from "../../stores/tablesStore";
import { useRoute } from "vue-router";

const tablesStore = useTablesStore();
const route = useRoute();

var formRef = ref(null);

onMounted(() => {
  tablesStore.addingNewTable = false; //редактирование
  tablesStore.loadTable(route.params.tableId).then((response) => {

  });
});
</script>

<template>
  <router-view> </router-view>
  <Layout>
    Редактировать таблицу<br />
    <div class="content">
      <FormTable ref="formRef" />
    </div>
  </Layout>
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
