<script setup>
import { onMounted, ref } from "vue";
import Layout from "../../components/layouts/Layout.vue";
import { NForm, NFormItem, NSpace, NButton, NInput, NGrid, NGridItem } from "naive-ui";
import { useTablesStore } from "../../stores/tablesStore";
import { useFormTableValidation } from "../../validations/tableValidation";

const tablesStore = useTablesStore();
var formRef = ref(null);
var buttonSaveIsLoading = ref(false);

const { rules } = useFormTableValidation(tablesStore.table);

function handleSaveButtonClick(e) {
  tablesStore.table.notFoundTable = false;
  e.preventDefault();
  formRef.value?.validate((errors) => {
    if (!errors) {
      buttonSaveIsLoading.value = true;
      tablesStore
        .CheckExistTable(
          tablesStore.table.database,
          tablesStore.table.shema,
          tablesStore.table.tableName
        )
        .then((response) => {
          console.log(response); //TODO
          buttonSaveIsLoading.value = false;
        })
        .catch((error) => {
          tablesStore.table.notFoundTable = true;
          formRef.value?.validate();
        })
        .finally(() => {
          buttonSaveIsLoading.value = false;
        });
    } else {
      console.log(errors);
      message.error("Invalid");
    }
  });
}

onMounted(() => {
  /*  tablesStore.loadTable().then((response) => {
    tables.value = response;
    console.log(tables);
  });*/
});
</script>

<template>
  <router-view> </router-view>
  <Layout>
    <div class="content">
      <n-form
        ref="formRef"
        size="small"
        :model="tablesStore.table"
        :rules="rules"
        label-placement="left"
        require-mark-placement="right-hanging"
        :style="{
          maxWidth: '640px',
        }"
      >
        <n-form-item label="Название" path="name">
          <n-input v-model:value="tablesStore.table.name" placeholder="" />
        </n-form-item>
        <n-form-item :show-feedback="false">
          <n-space>
            <n-form-item label="База данных" label-placement="top" path="database">
              <n-input v-model:value="tablesStore.table.database" placeholder="" />
            </n-form-item>
            <n-form-item label="Схема" label-placement="top" path="shema">
              <n-input v-model:value="tablesStore.table.shema" placeholder="" />
            </n-form-item>
            <n-form-item label="Таблица" label-placement="top" path="tableName">
              <n-input v-model:value="tablesStore.table.tableName" placeholder="" />
            </n-form-item>
          </n-space>
        </n-form-item>
        <n-form-item label="Описание">
          <n-input v-model:value="tablesStore.table.description" placeholder="" />
        </n-form-item>

        <div style="display: flex; justify-content: flex-end">
          <n-button
            :loading="buttonSaveIsLoading"
            round
            type="primary"
            @click="handleSaveButtonClick"
          >
            Проверить
          </n-button>
        </div>
      </n-form>
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
