<script setup>
import { h, ref } from "vue";
import { NIcon, NMenu, NLayoutSider } from "naive-ui";
import {
  BookOutline as BookIcon,
  PersonOutline as PersonIcon,
  WineOutline as WineIcon,
} from "@vicons/ionicons5";

function renderIcon(icon) {
  return () => h(NIcon, null, { default: () => h(icon) });
}

var collapsed = ref(true);

const leftMenuOptions = [
  {
    label: "Диспансеризация",
    key: "disp",
    icon: renderIcon(BookIcon),
  },
];
</script>
<template>
  <n-layout-sider
    bordered
    show-trigger
    :collapsed="collapsed"
    collapse-mode="width"
    :collapsed-width="54"
    :width="200"
    :native-scrollbar="false"
    @collapse="collapsed = true"
    @expand="collapsed = false"
  >
    <n-menu :collapsed-width="54" :collapsed-icon-size="18" :options="leftMenuOptions" />
  </n-layout-sider>
</template>
<style></style>
