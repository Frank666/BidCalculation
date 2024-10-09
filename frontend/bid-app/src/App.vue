<template>
  <v-app>
    <BidTool />
  </v-app>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import BidTool from "./views/BidTool.vue";

export default defineComponent({
  name: "App",
  components: {
    BidTool,
  },
});
</script>
