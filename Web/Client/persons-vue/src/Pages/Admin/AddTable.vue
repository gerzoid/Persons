<script setup>
import { onMounted, ref } from "vue";
import Layout from "../../components/layouts/Layout.vue";
import { NForm, NFormItem, NSpace, NButton, NInput, NGrid, NGridItem } from "naive-ui";
import { useTablesStore } from "../../stores/tablesStore";

const tablesStore = useTablesStore();

var formRef = ref(null);

var buttonSaveIsLoading = ref(false);

var model = ref({
  name: null,
  database: null,
  shema: null,
  tableName: null,
  description: null,
});

var rules = {
  name: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
  database: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
  shema: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
  tableName: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
};
function handleSaveButtonClick(e) {
  e.preventDefault();
  formRef.value?.validate((errors) => {
    if (!errors) {
      buttonSaveIsLoading.value = true;
      tablesStore
        .CheckExistTable(model.value.database, model.value.shema, model.value.tableName)
        .then((response) => {
          buttonSaveIsLoading.value = false;
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
        :model="model"
        :rules="rules"
        label-placement="left"
        require-mark-placement="right-hanging"
        :style="{
          maxWidth: '640px',
        }"
      >
        <n-form-item label="Название" path="name">
          <n-input v-model:value="model.name" placeholder="" />
        </n-form-item>
        <n-form-item :show-feedback="false">
          <n-space>
            <n-form-item label="База данных" label-placement="top" path="database">
              <n-input v-model:value="model.database" placeholder="" />
            </n-form-item>
            <n-form-item label="Схема" label-placement="top" path="shema">
              <n-input v-model:value="model.shema" placeholder="" />
            </n-form-item>
            <n-form-item label="Таблица" label-placement="top" path="tableName">
              <n-input v-model:value="model.tableName" placeholder="" />
            </n-form-item>
          </n-space>
        </n-form-item>
        <n-form-item label="Описание">
          <n-input v-model:value="model.description" placeholder="" />
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
