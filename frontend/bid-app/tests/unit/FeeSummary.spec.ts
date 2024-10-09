import { mount } from "@vue/test-utils";
import { describe, it, expect } from "vitest";
import FeeSummary from "../../src/components/FeesSummary.vue";

describe("FeeSummary.vue", () => {
  it("displays fees correctly", () => {
    const fees = {
      buyerFee: 50,
      specialFee: 100,
      associationFee: 15,
      storageFee: 100,
      totalPrice: 265,
    };

    const wrapper = mount(FeeSummary, {
      props: {
        fees,
      },
    });

    expect(wrapper.text()).toContain("Buyer Fee: $50.00");
    expect(wrapper.text()).toContain("Seller Fee: $100.00");
    expect(wrapper.text()).toContain("Association Fee: $15.00");
    expect(wrapper.text()).toContain("Storage Fee: $100.00");
    expect(wrapper.text()).toContain("Total Price: $265.00");
  });
});
