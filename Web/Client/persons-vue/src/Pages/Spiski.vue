<script setup>
import { onMounted, ref } from "vue";
import { NTable, NTabs, NTabPane } from "naive-ui";
import Layout from "../components/layouts/Layout.vue";
import { useTablesStore } from "../stores/tablesStore";

const tablesStore = useTablesStore();
var tables = ref([]);

onMounted(() => {
  tablesStore.getTables().then((response) => {
    tables.value = response;
    console.log(tables);
  });
});
</script>

<template>
  <router-view> </router-view>
  <Layout>
    <div class="content">
      <n-tabs type="segment" animated>
        <n-tab-pane name="Активные" tab="Active">
          <n-table>
            <thead>
              <tr>
                <th>Наименование</th>
                <th>Описание</th>
                <th>Дата создания</th>
                <th>Дата закрытия</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="table in tables">
                <td>{{ table.name }}</td>
                <td>{{ table.description }}</td>
                <td>{{ table.createdAt }}</td>
                <td>{{ table.expiredAt }}</td>
              </tr>
            </tbody>
          </n-table>
        </n-tab-pane>
        <n-tab-pane name="Закрытые" tab="Closed"> </n-tab-pane>
      </n-tabs>
    </div>
  </Layout>
</template>
<style>
.content {
  padding: 20px;
}
</style>
