<script setup>
import { onMounted, ref } from "vue";
import Layout from "../../components/layouts/Layout.vue";
import { NForm, NFormItem, NSpace, NButton, NInput, NGrid, NGridItem } from "naive-ui";
import { useTablesStore } from "../../stores/tablesStore";

const tablesStore = useTablesStore();

var table = ref([]);
var formRef = ref(null);

var model = ref({
  inputValue: null,
});
var rules = {
  inputName: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
  inputDatabase: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
  inputShema: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
  inputTableName: {
    required: true,
    trigger: ["input", "blur"],
    message: "Поле не может быть пустым",
  },
};

function handleValidateButtonClick(e) {
  e.preventDefault();
  formRef.value?.validate((errors) => {
    if (!errors) {
      message.success("Valid");
    } else {
      console.log(errors);
      message.error("Invalid");
    }
  });
}

onMounted(() => {
  tablesStore.loadTable().then((response) => {
    tables.value = response;
    console.log(tables);
  });
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
        idth="auto"
        :style="{
          maxWidth: '640px',
        }"
      >
        <n-form-item label="Название" path="inputName">
          <n-input v-model:value="model.name" placeholder="" />
        </n-form-item>
        <n-form-item :show-feedback="false">
          <n-space>
            <n-form-item label="База данных" label-placement="top" path="inputDatabase">
              <n-input v-model:value="model.database" placeholder="" />
            </n-form-item>
            <n-form-item label="Схема" label-placement="top" path="inputShema">
              <n-input v-model:value="model.shema" placeholder="" />
            </n-form-item>
            <n-form-item label="Таблица" label-placement="top" path="inputTableName">
              <n-input v-model:value="model.tableName" placeholder="" />
            </n-form-item>
          </n-space>
        </n-form-item>
        <n-form-item label="Описание" path="inputDescription">
          <n-input v-model:value="model.description" placeholder="" />
        </n-form-item>

        <div style="display: flex; justify-content: flex-end">
          <n-button round type="primary" @click="handleValidateButtonClick">
            Validate
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
