<template>
  <v-divider></v-divider>
  <v-list lines="one">
    <v-list-item>
      <v-list-item-content
        >Buyer Fee: ${{
          fees?.buyerFee.toFixed(2) ?? "0.00"
        }}</v-list-item-content
      >
    </v-list-item>
    <v-list-item>
      <v-list-item-content
        >Seller Fee: ${{
          fees?.specialFee?.toFixed(2) ?? "0.00"
        }}</v-list-item-content
      >
    </v-list-item>
    <v-list-item>
      <v-list-item-content
        >Association Fee: ${{
          fees?.associationFee?.toFixed(2) ?? "0.00"
        }}</v-list-item-content
      >
    </v-list-item>
    <v-list-item>
      <v-list-item-content
        >Storage Fee: ${{
          fees?.storageFee?.toFixed(2) ?? "0.00"
        }}</v-list-item-content
      >
    </v-list-item>
    <v-list-item>
      <v-list-item-content
        ><strong
          >Total Price: ${{ fees?.totalPrice?.toFixed(2) ?? "0.00" }}</strong
        ></v-list-item-content
      >
    </v-list-item>
  </v-list>
</template>

<script lang="ts">
import { defineComponent, PropType } from "vue";

export default defineComponent({
  name: "FeeSummary",
  props: {
    fees: {
      type: Object as PropType<Fees | null>,
      required: true,
    },
  },
});
</script>
