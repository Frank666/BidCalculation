<template>
  <v-container>
    <v-card class="pa-md-4 mx-lg-auto" max-width="450" variant="outlined">
      <v-row>
        <v-col>
          <h2>The Bid Calculation Tool</h2>
        </v-col>
      </v-row>

      <v-row>
        <v-col cols="12" md="12">
          <v-text-field
            v-model="basePrice"
            label="Car Base Price"
            type="number"
            min="0"
            required
            name="price"
            :error-messages="basePriceError"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col cols="12" md="12">
          <v-select
            v-model="carType"
            :items="carTypes"
            label="Car Type"
            required
            :error-messages="carTypeError"
          />
        </v-col>
      </v-row>

      <v-row>
        <v-col>
          <v-btn @click="getFees" color="primary"> Calculate Fees </v-btn>
        </v-col>
      </v-row>

      <v-row>
        <fee-summary :fees="fees" />
      </v-row>
    </v-card>
  </v-container>
</template>

<script lang="ts">
import { defineComponent, ref, computed } from "vue";
import { BidCalculationService } from "../services/BidCalculationService";
import FeeSummary from "../components/FeesSummary.vue";

export default defineComponent({
  name: "BidTool",
  components: {
    FeeSummary,
  },
  setup() {
    const basePrice = ref<number>(null);
    const carType = ref<string>("");
    const fees = ref<Fees | null>(null);
    const carTypes = ["Common", "Luxury"]; // TODO: this should come from api instead to have it here
    const basePriceError = ref<string | null>(null);
    const carTypeError = ref<string | null>(null);

    const getFees = async () => {
      try {
        basePriceError.value = null;
        carTypeError.value = null;

        // Validate basePrice
        if (basePrice.value === null || basePrice.value <= 0) {
          basePriceError.value = "Please enter a valid car base price";
          return;
        }

        // Validate vehicleType
        if (!carType.value) {
          carTypeError.value = "Please select a car type";
          return;
        }

        fees.value = await BidCalculationService(
          basePrice.value,
          carType.value
        );
      } catch (error) {
        console.error("Error fetching fees:", error);
      }
    };

    return {
      basePrice,
      carType,
      carTypes,
      fees,
      getFees,
      basePriceError,
      carTypeError,
    };
  },
});
</script>
