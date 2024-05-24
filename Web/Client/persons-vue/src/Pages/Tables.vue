<script setup>
import { onMounted, ref } from "vue";
import { NTable, NTabs, NTabPane, NButton } from "naive-ui";
import Layout from "../components/layouts/Layout.vue";
import { useTablesStore } from "../stores/tablesStore";

const tablesStore = useTablesStore();
var tables = ref([]);

onMounted(() => {
  tablesStore.loadTables().then((response) => {
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
          <n-table size="small">
            <thead>
              <tr>
                <th>Наименование</th>
                <th>Описание</th>
                <th>Дата создания</th>
                <th>Дата закрытия</th>
                <th>Действия</th>
              </tr>
            </thead>
            <tbody>
              <tr v-for="table in tables">
                <td>{{ table.name }}</td>
                <td>{{ table.description }}</td>
                <td>{{ table.createdAt }}</td>
                <td>{{ table.expiredAt }}</td>
                <td>
                  <router-link to="/table/3">
                    <n-button strong secondary type="primary"> Открыть </n-button>
                  </router-link>
                </td>
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
  display: flex;
  flex: auto;
}

.table-link {
  display: contents;
}
</style>
