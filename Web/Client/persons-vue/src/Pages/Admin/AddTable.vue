<script setup>
import { onMounted, ref } from "vue";
import Layout from "../../components/layouts/Layout.vue";
import FormTable from "../../components/table/FormTable.vue";
import { useTablesStore } from "../../stores/tablesStore";

var formRef = ref(null);

onMounted(() => {});
</script>

<template>
  <router-view> </router-view>
  <Layout>
    <div class="content">
      Добавление таблицы
      <form-table></form-table>
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
