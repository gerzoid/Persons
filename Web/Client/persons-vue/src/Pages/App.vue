<script setup>
import {
  NLayout,
  NLayoutHeader,
  NLayoutFooter,
  NLayoutContent,
  NLayoutSider,
  NSpace,
} from "naive-ui";
</script>

<template>
  <n-space vertical size="large">
    <n-layout has-sider>
      <n-layout-sider content-style="padding: 24px;"> Handian Bridge </n-layout-sider>
      <n-layout>
        <n-layout-header>Yiheyuan Road</n-layout-header>
        <n-layout-content content-style="padding: 24px;">
          Pingshan Road
        </n-layout-content>
      </n-layout>
      <n-layout-footer bordered position="absolute" style="height: 64px; padding: 24px"
        >!!!!</n-layout-footer
      >
    </n-layout>
  </n-space>
</template>
<style scoped>
.n-layout-header,
.n-layout-footer {
  background: rgba(128, 128, 128, 0.2);
  padding: 24px;
}

.n-layout-sider {
  background: rgba(128, 128, 128, 0.3);
}

.n-layout-content {
  background: rgba(128, 128, 128, 0.4);
}
</style>
