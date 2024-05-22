<script setup>
import { onMounted } from "vue";
import Layout from "../components/layouts/Layout.vue";
import { useTablesStore } from "../stores/tablesStore";

const tablesStore = useTablesStore();
onMounted(() => {
  tablesStore.getTables().then(response=>{console.log(response)});
});
</script>

<template>
    <router-view> </router-view>
    <Layout>
    !!!!!!!!!!!!!
    </Layout>
</template>
