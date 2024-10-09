import { mount } from "@vue/test-utils";
import { describe, it, expect, vi } from "vitest";
import BidTool from "../../src/views/BidTool.vue";

describe("BidTool component", () => {
  it("renders correctly", async () => {
    const wrapper = mount(BidTool);

    expect(wrapper.find("h2").text()).toContain("The Bid Calculation Tool");
    expect(wrapper.find('[type="number"]').exists()).toBe(true);
  });

  //TODO: test events
});
