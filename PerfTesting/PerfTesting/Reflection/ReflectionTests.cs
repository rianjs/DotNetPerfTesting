using System.Reflection;
using BenchmarkDotNet.Attributes;

namespace PerfTesting.Reflection;

[MemoryDiagnoser, ShortRunJob]
public class ReflectionTests
{
    [Benchmark]
    public Dictionary<string, string> GetFields()
        => FieldNames.GetFieldNameMappings();

    [Benchmark]
    public Dictionary<string, string> GetCachedFields()
        => FieldNames.CachedFieldNameMappings();
}

public static class FieldNames
{
    public const string BusinessName =  "lit_business_name";
    public const string BusinessAge = "date_business_age";
    public const string CompanyId =  "company_id";
    public const string UserId = "user_id";
    public const string SsoUserId = "lit_sso_user_id";
    // Despite how these are named, they reflected "past 365 days" rather than 12 months
    // with code changes made Nov 2024. They should eventually be ported over to new names.
    public const string TopMerchantName = "lit_top_merchant_name_12m";
    public const string TopMerchantTransactionCount = "int_top_merchant_transaction_count_12m";
    public const string TopMerchantTransactionTotal = "dbl_top_merchant_transaction_total_12m";
    public const string LastLogin = "date_last_login";
    public const string TenantId = "tenant_id";
    public const string TopPaymentProviderName = "lit_top_payment_provider_name_12m";
    public const string TopPaymentProviderTransactionCount = "int_top_payment_provider_transaction_count_12m";
    public const string TopPaymentProviderTransactionTotal = "dbl_top_payment_provider_transaction_total_12m";
    public const string BillPayProvidersCount = "int_bill_pay_providers_count_12m";
    public const string WirePaymentsTransactionCount = "int_wire_payments_transaction_count_12m";
    public const string WirePaymentsTransactionTotals = "dbl_wire_payments_transaction_totals_12m";
    public const string CheckWritingTransactionCount = "int_check_writing_txn_count_12m";
    public const string CheckWritingTransactionTotals = "dbl_check_writing_txn_totals_12m";
    public const string TopPayrollProviderName = "lit_top_payroll_provider_name_365d";
    public const string TopPayrollProviderTransactionCount = "int_top_payroll_provider_transaction_count_365d";
    public const string TopPayrollProviderTransactionTotal = "dbl_top_payroll_provider_transaction_total_365d";

    /// <summary>
    /// Maps from friendly field names to names used in the search engine
    /// </summary>
    // public static Dictionary<string, string> FieldNameMappings => GetFieldNameMappings();

    public static Dictionary<string, string> GetFieldNameMappings() =>
        typeof(FieldNames)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(field => field.IsLiteral && !field.IsInitOnly) // This specifically targets const fields
            .ToDictionary(
                x => x.Name,
                x => (string)x.GetValue(null)!
            );

    private static readonly Lazy<Dictionary<string, string>> _fieldNames
        = new(GetFieldNameMappings, LazyThreadSafetyMode.PublicationOnly);

    public static Dictionary<string, string> CachedFieldNameMappings() => _fieldNames.Value;
}