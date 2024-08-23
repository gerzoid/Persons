<script setup>
import { onMounted, ref } from "vue";
import Layout from "../../components/layouts/Layout.vue";
import FormTable from "../../components/table/FormTable.vue";
import { useTablesStore } from "../../stores/tablesStore";
import { Table } from "../../models/table.js";

const tablesStore = useTablesStore();

var formRef = ref(null);

onMounted(() => {
  tablesStore.table = new Table();
  tablesStore.table.userId = 
  tablesStore.addingNewTable = true; //Создание
});
</script>

<template>
  <router-view> </router-view>
  <Layout>
    Добавить таблицу<br />
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
