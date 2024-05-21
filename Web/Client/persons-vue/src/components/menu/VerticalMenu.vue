<script setup>
import { h } from "vue";
import { NIcon, NMenu, NLayoutSider } from "naive-ui";
import {
  BookOutline as BookIcon,
  PersonOutline as PersonIcon,
  WineOutline as WineIcon,
} from "@vicons/ionicons5";

function renderIcon(icon) {
  return () => h(NIcon, null, { default: () => h(icon) });
}

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
    collapse-mode="width"
    :collapsed-width="64"
    :width="240"
    :native-scrollbar="false"
  >
    <n-menu :collapsed-width="64" :collapsed-icon-size="22" :options="leftMenuOptions" />
  </n-layout-sider>
</template>
<style></style>
