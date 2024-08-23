<script setup>
import { ref, reactive } from "vue";
import { NForm, NFormItem, NSpace, NButton, NInput, NSpin } from "naive-ui";
import { useTablesStore } from "../../stores/tablesStore";
import { useRouter } from "vue-router";
import { useFormTableValidation } from "../../validations/tableValidation";

const tablesStore = useTablesStore();
const router = useRouter();

var formRef = ref(null);
var buttonSaveIsLoading = ref(false);

const { rules } = useFormTableValidation(tablesStore.validation);

function handleSaveButtonClick(e) {
  tablesStore.SaveTable().then((response) => {
    router.push("/tables");
  });
}
function handleCheckButtonClick(e) {
  tablesStore.validation.notFoundTable = false;
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
          buttonSaveIsLoading.value = false;
        })
        .catch((error) => {
          tablesStore.setNotFoundTable(true);
          formRef.value?.validate();
        })
        .finally(() => {
          buttonSaveIsLoading.value = false;
        });
    } else {
      console.log(errors);
      //message.error("Invalid");
    }
  });
}
</script>

<template>
  <n-spin
    :show="tablesStore.loading"
    size="large"
    stroke="black"
    content-style="color:black;"
    :stroke-width="30"
  >
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
          type="info"
          @click="handleCheckButtonClick"
        >
          Проверить
        </n-button>
        <n-button
          type="primary"
          :disabled="!tablesStore.validation.checked"
          @click="handleSaveButtonClick"
        >
          Сохранить
        </n-button>
      </div>
    </n-form>
  </n-spin>
</template>
<style></style>
