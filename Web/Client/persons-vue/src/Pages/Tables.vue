<script setup>
import { onMounted, ref } from "vue";
import { NTable, NTabs, NTabPane, NButton, NSpace } from "naive-ui";
import Layout from "../components/layouts/Layout.vue";
import { NSpin } from "naive-ui";
import { useTablesStore } from "../stores/tablesStore";
import { useAuthStore } from "../stores/authStore";

const tablesStore = useTablesStore();
const authStore = useAuthStore();

onMounted(() => {
  console.log('loadTables');
  tablesStore.loadTables().then((response) => {});
});
</script>

<template>
  <router-view> </router-view>
  <Layout>
    <div class="content">
      <n-tabs type="segment" animated>
        <n-tab-pane name="Active" tab="Активные">
          <n-spin
            :show="tablesStore.loading"
            size="large"
            stroke="black"
            content-style="color:white;"
            :stroke-width="30"
          >
            <router-link v-if="authStore.isAdmin" :to="{ name: 'AddTable' }">Добавить таблицу</router-link>
            <n-table size="small">
              <thead>
                <tr>
                  <th>Наименование</th>
                  <th>Описание</th>
                  <th>Дата создания</th>
                  <th>Дата закрытия</th>
                  <th>Автор</th>
                  <th>Действия</th>
                </tr>
              </thead>
              <tbody>
                <tr v-for="table in tablesStore.tables">
                  <td>{{ table.name }}</td>
                  <td>{{ table.description  }}</td>
                  <td>{{ table.createdAt }}</td>
                  <td>{{ table.expiredAt }}</td>
                  <td>{{ table.userId }}</td>
                  <td>
                    <n-space>
                      <router-link
                        :to="{ name: 'EditTable', params: { tableId: table.tableId } }"
                      >
                        <n-button v-if="authStore.isAdmin" strong secondary type="warning"
                          >Редактировать
                        </n-button>
                      </router-link>

                      <router-link :to="{ name: 'PersonsTable', params: { tableId: table.tableId } }">
                        <n-button strong secondary type="primary"> Открыть </n-button>
                      </router-link>
                    </n-space>
                  </td>
                </tr>
              </tbody>
            </n-table>
          </n-spin>
        </n-tab-pane>
        <n-tab-pane name="Closed" tab="Закрытые"> </n-tab-pane>
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
